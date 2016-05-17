namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects.Tables {
    public class EmailContent : BaseTableObject {
        public int EmailTypeID { get; set; }

        public string SubjectLine { get; set; }

        public string Body { get; set; }
    }
}