namespace BuildManifest
{
    public class JSONObject
    {
        public string ConvertToObj(string path,string pre)
        {
        
            TaoOn obj = new TaoOn();
            jsonCon jsonCon = new jsonCon();
            jsonCon.md5 = "md5";
            jsonCon.hashcode = new MD5().GetMD5HashFromFile(path);
            obj.path = path.Remove(0,pre.Length+1).Replace(@"\","/");

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