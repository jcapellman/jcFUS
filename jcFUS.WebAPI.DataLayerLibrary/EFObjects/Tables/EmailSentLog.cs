using System;

namespace jcFUS.WebAPI.DataLayerLibrary.EFObjects.Tables {
    public class EmailSentLog : BaseTableObject {
        public int EmailTypeID { get; set; }

        public Guid ReceiverUserGUID { get; set; }

        public string SubjectLine { get; set; }

        public string Body { get; set; }
    }
}