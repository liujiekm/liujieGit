using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Etron_Model
{
    [DataContract]
    public class ZTreeModel
    {
        [DataMember]
        private Int32 id;

        [DataMember]
        private Int32? parentId;

        [DataMember]
        private String name;

        [DataMember]
        private String icon;

        [DataMember]
        private String treeType;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int? ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string TreeType
        {
            get { return treeType; }
            set { treeType = value; }
        }


    }
}
