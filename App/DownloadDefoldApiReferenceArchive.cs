﻿using RestSharp;

namespace App
{
    public class DownloadDefoldApiReferenceArchive
    {
        public async Task<DefoldApiReferenceArchive> DownloadAsync(DefoldRelease release)
        {
            byte[]? apiReferenceZip = await DownloadApiReferenceZip(release);
            return new DefoldApiReferenceArchive(apiReferenceZip);
        }

        #region Private Methods
        protected virtual async Task<byte[]?> DownloadApiReferenceZip(DefoldRelease release)
        {
            var client = new RestClient(); // TODO: singleton
            var request = new RestRequest(release.RefDocUrl(), Method.Get);
            var response = await client.GetAsync(request);
            return response.RawBytes;
        }
        #endregion
    }
}
