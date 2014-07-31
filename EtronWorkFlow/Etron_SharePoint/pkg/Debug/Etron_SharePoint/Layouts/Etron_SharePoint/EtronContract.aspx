<%@ Assembly Name="Etron_SharePoint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=94fea3e72648fba3" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EtronContract.aspx.cs" Inherits="Etron_SharePoint.Layouts.Etron_SharePoint.EtronContract" DynamicMasterPageFile="~masterurl/default.master" %>

<%@ Register Src="~/_CONTROLTEMPLATES/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">


    <link href="css/zTreeStyle.css" rel="stylesheet" />
    <link href="css/pagination.css" rel="stylesheet" />
    <%--<link href="css/bootstrap.css" rel="stylesheet" />
    

    <script src="js/bootstrap.js" type="text/javascript"></script>--%>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.ztree.all-3.5.min.js" type="text/javascript"></script>
    <script src="js/jquery.pagination.js" type="text/javascript"></script>


    <style type="text/css">
        #div_left
        {
            width: 20%;
            float: left;
        }

        #div_main
        {
            width: 80%;
            float: left;
        }


        .contractInfo
        {
            margin-right: 10px;
            margin-bottom: 10px;
            position: relative;
            float: left;
            height: 130px;
            width: 200px;
            box-shadow: 2px 2px 10px #909090;
        }

        .peopleInfo
        {
            float: left;
            position: absolute;
            margin-left: 95px;
            margin-top: 3px;
            font-size: 13px;
        }

        .peoplePhoto
        {
            margin-left: 5px;
            margin-top: 5px;
            float: left;
        }

        .isNew
        {
            float: left;
            clear: left;
            margin-left: 55px;
            margin-top: 110px;
            position: absolute;
        }

        #Pagination
        {
            float: left;
            margin-left: 100px;
            text-align: center;
            margin-top: 10px;
        }
    </style>


    <script type="text/javascript">
        var pageIndex = 0; //页面索引初始值
        var pageSize = 12; //每页显示条数初始化，修改显示条数，修改这里即可 

        var opt = {
            callback: PageCallback,
            prev_text: '上一页',       //上一页按钮里text
            next_text: '下一页',       //下一页按钮里text
            items_per_page: pageSize,  //显示条数
            num_display_entries: 6,    //连续分页主体部分分页条目数
            current_page: pageIndex,   //当前页索引
            num_edge_entries: 2        //两侧首尾分页条目数
        };


        $(function() {
            //获得总页数
            $.get('./ContractRetrive.ashx', {Type:'GetAllCount'},
              function(data) {
                  InitTable(0); //Load事件，初始化表格数据，页面索引为0（第一页） 
                  //分页，PageCount是总条目数，这是必选参数，其它参数都是可选
                  $("#Pagination").pagination(data,opt );

              });
        });
        
        function PageCallback(index, jq) {
            InitTable(index);
        }
        //请求数据
        function InitTable(pageIndex) {

            $.get('./ContractRetrive.ashx', {Type:'GetContent', DeptId: $('#hdn_deptId').val(), PageIndex: pageIndex, PageSize: pageSize },
                function(contractData) {
                    var temp = $.parseJSON(contractData);
                    var content='';
                    $.each(temp, function(index, item) {
                        var urlString='';
                        if (item.Photo) {
                            urlString= ' http://192.168.1.11' + item.Photo.replace("~","");
                        } else {
                            urlString = 'image/person.gif';
                        }

                        content += '<div class="contractInfo">';
                        content += '<div class="peoplePhoto">';
                        
                        content += '<img src='+urlString+' height="108" width="82" alt=""/>';

                        content += ' </div>';

                        content += ' <div class="isNew">';
                        
                        if (item.IsNew == true) {
                            content += '<img src="image/new3.gif" />';
                            
                        }

                        content += ' </div>';

                        content += '<div class="peopleInfo">';

                        content += '<div><span>' + item.Name + '</span></div>';
                        content += '<div><span>' + item.Ename + '</span></div>';
                        content += '<div><span>' + item.Gender + '</span></div>';
                        content += '<div><span>' + item.Position + '</span></div>';
                        content += '<div><span>' + item.MobilePhone + '</span></div>';
                        
                        content += '<div><span>' + item.PhoneSuffix + '</span></div>';
                        content += '<div><span>' + item.NewExtension + '</span></div>';
                       
                        content += '<div><a target="_blank" href="mailto:' + item.Email + '">'+item.Email+'</a></div>';
                        
                        content += '</div>';

                        content += '</div>';
                    });
                    $("#main").empty();
                    $("#main").append(content); //将返回的数据追加到表格

                }
            );
        }
    
        var zTreeNodes = <%=zTreeNodes%>;
        var setting = {   
            view: {
                selectedMulti: false
            },
            key: {
                name:"Name",
                
            },
            data: {
                simpleData: {
                    enable:true,
                    idKey:"id",
                    pIdKey:"parentId",
                    rootPId:0
                }
            },
            callback: {
                onClick: zTreeOnClick
            }
        };
        $(function() {

            $.fn.zTree.init($("#dept_tree"), setting, zTreeNodes);
            

            var treeObj = $.fn.zTree.getZTreeObj("dept_tree");
            treeObj.expandAll(true);


        });

        //单击节点事件
        function zTreeOnClick(event, treeId, treeNode, clickFlag) {

            $('#hdn_deptId').val(treeNode.id);

            $.get('./ContractRetrive.ashx', {Type:'GetCount', DeptId: treeNode.id },
            function(data) {
                InitTable(0); //Load事件，初始化表格数据，页面索引为0（第一页） 
                //分页，PageCount是总条目数，这是必选参数，其它参数都是可选
                $("#Pagination").pagination(data, opt);
            });
        }

    </script>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="div_left">
        <ul id="dept_tree" class="ztree"></ul>


    </div>

    <div id="div_main">

        <!--个人名片方式呈现通讯录信息-->

        <div id="main">



            <!--
            <div class="contractInfo">


                <div class="peoplePhoto">
                    <img src="image/person.gif" width="82px" height="108px" />

                </div>
                <div class="isNew">
                    <img src="image/new3.gif" />

                </div>
                <div class="peopleInfo">

                    <div>Jonathen</div>
                    <div>Jonathen</div>
                    <div>Jonathen</div>
                    <div>Jonathen</div>
                    <div>Jonathen</div>
                    <div>Jonathen</div>
                    <div>Jonathen</div>
                </div>




            </div>
                -->
        </div>


        <!-- <table class="table table-striped">
            <thead>
                <tr>
                    <td>照片</td>
                    <td>姓名</td>
                    <td>英文名</td>
                    <td>性别</td>
                    <td>职位</td>
                    <td>手机</td>
                    <td>集团短号</td>
                    <td>新分机</td>
                    <td>E-mail</td>

                </tr>
            </thead>
            <tbody id="contractBody" style="text-align: center">
               
            </tbody>
        </table>
           -->

        <div id="Pagination"></div>

        <input type="hidden" id="hdn_pageCount" name="hdn_pageCount" />
        <input type="hidden" id="hdn_deptId" name="hdn_deptId" />


    </div>

</asp:Content>

<%--<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
应用程序页
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
我的应用程序页
</asp:Content>--%>
