namespace BuildManifest
{
    public class JSONObject
    {
        public string ConvertToObj(string path)
        {
            //dynamic obj = new ExpandoObject();
            //obj.path = path;
            //jsonCon jsoncon = new jsonCon();
            //jsoncon.md5 = "md5";
            //jsoncon.hashcode = new MD5().GetMD5HashFromFile(path);
            //obj.endcode = jsoncon;
            //return obj;
            TaoOn obj = new TaoOn();
            jsonCon jsonCon = new jsonCon();
            jsonCon.md5 = "md5";
            jsonCon.hashcode = new MD5().GetMD5HashFromFile(path);
            obj.path = path;

            obj.con = jsonCon;

            var objstring = "\"" + obj.path + "\"" + ":{" + "\"" + obj.con.md5 + "\"" + ":\"" + obj.con.hashcode + "\"" + "}";
            return objstring;
        }
    }

    public class TaoOn
    {
        public string path { get; set; }
        public jsonCon con { get; set; }
    }

    public class jsonCon
    {
        public string md5 { get; set; }
        public string hashcode { get; set; }
    }
}