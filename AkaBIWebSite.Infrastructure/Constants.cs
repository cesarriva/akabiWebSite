namespace AkaBIWebSite.Infrastructure
{
    public static class Constants
    {
        /*Email constants*/
        public const string SmtpHostKey = "SmtpHost";
        public const string SmtpPortKey = "SmtpPort";
        public const string SmtpUserNameKey = "SmtpUserName";
        public const string SmtpUserPasswordKey = "SmtpUserPassword";
        public const string ContactToKey = "ContactTo";
        public const string JobApplicationToKey = "JobApplicationTo";

        /*Taleevo constants*/
        public const string TaleevoBaseUrlApiKey = "TaleevoBaseUrlApi";
        public const string TaleevoCompanyIdKey = "TaleevoCompanyId";
        public const string TaleevoGetPositionsUrlKey = "TaleevoGetPositionsUrl";

        /*Facebook constants*/
        public const string FacebookAccessTokenUrl = "oauth/access_token";
        public const string FacebookClientIdKey = "FacebookClientId";
        public const string FacebookClientSecretKey = "FacebookClientSecret";
        public const string FacebookPageIdKey = "FacebookPageId";
        public const string GetAllPagePostsUrlFormat = "{0}/posts?fields=created_time,message,id,full_picture,picture,description,link,permalink_url";
        public const string GetPostByIdUrlFormat = "{0}?fields=description,created_time,full_picture,message,link,permalink_url,picture";
    }
}
