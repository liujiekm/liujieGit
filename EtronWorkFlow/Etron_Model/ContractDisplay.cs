using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etron_Model
{
    [Serializable]
    public class ContractDisplay
    {
        private String name;

        private String ename;

        private String gender;

        private String position;

        private String mobilePhone;

        private String phoneSuffix;

        private String newExtension;

        private String email;

        private String photo;

        private Boolean isNew;



        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Ename
        {
            get { return ename; }
            set { ename = value; }
        }


        public String Gender
        {
            set { gender = value; }
            get
            {
                if (this.gender.Equals("M"))
                {
                    return "男";
                }
                else
                {
                    return "女";

                }

            }
        }


        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        public string PhoneSuffix
        {
            get { return phoneSuffix; }
            set { phoneSuffix = value; }
        }

        public string NewExtension
        {
            get { return newExtension; }
            set { newExtension = value; }
        }


        public String Email
        {
            set { email = value; }
            get { return email; }
        }


        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }



        public Boolean IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }


    }
}
