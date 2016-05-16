using System;
using System.Collections.Generic;
using System.Linq;

using jcFUS.PCL.Enums;
using jcFUS.WebAPI.DataLayerLibrary.Entities;
using jcFUS.WebAPI.Helpers;

namespace jcFUS.WebAPI.Managers {
    public class EmailManager : BaseManager {
        public bool SendEmail(Guid receiverUserGUID, EmailTypes emailType)
            => SendEmail(new List<Guid> { receiverUserGUID }, emailType);

        public bool SendEmail(List<Guid> receiverUserGUIDs, EmailTypes emailType) {
            using (var eFactory = new EFModel()) {
                var users = eFactory.UserSet.Where(a => receiverUserGUIDs.Contains(a.GUID)).ToList();

                var subject = string.Empty;
                var body = string.Empty;

                foreach (var user in users) {
                    recordEmail(emailType, user.GUID, subject, body);

                    EmailHelper.SendEmail(user.EmailAddress, subject, body);
                }

                return true;
            }
        }

        private void recordEmail(EmailTypes emailType, Guid receiverUserGUID, string subject, string body) {
            using (var eFactory = new EFModel()) {

            }
        }
    }
}