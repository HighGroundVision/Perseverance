using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace HGV.Perserverance
{
	public class MatchStorageService
	{
		private const string PERSERVERANCE_STORAGE_CONNECTION_STRING = "Perserverance.Storage";

		private const string RAW_REPLAY_CONTAINER = "match-replays";
		private const string RAW_REPLAY_REF_NAME = "{0}.dem";

		private const string PARSED_REPLAY_CONTAINER = "match-logs";
		private const string PARSED_REPLAY_REF_NAME = "{0}.json";

		private async Task<CloudBlobContainer> GetContainer(string name)
		{
			var connectionString = ConfigurationManager.AppSettings[PERSERVERANCE_STORAGE_CONNECTION_STRING];
			if (connectionString == null)
				throw new ArgumentNullException(nameof(connectionString));

			// Retrieve storage account from connection string.
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
			if (storageAccount == null)
				throw new ArgumentNullException(nameof(storageAccount));

			// Create the blob client.
			CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
			if (blobClient == null)
				throw new ArgumentNullException(nameof(blobClient));

			// Retrieve a reference to a container.
			CloudBlobContainer container = blobClient.GetContainerReference(name);
			if (container == null)
				throw new ArgumentNullException(nameof(container));

			// Create the container if it doesn't already exist.
			await container.CreateIfNotExistsAsync();

			container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

			return container;
		}

		public async Task StoreRawReplay(ulong id, byte[] data)
		{
			if (id == 0)
				throw new ArgumentOutOfRangeException(nameof(id));

			if (data == null)
				throw new ArgumentNullException(nameof(data));

			if (data.Length == 0)
				throw new ArgumentOutOfRangeException(nameof(data));

			var container = await GetContainer(RAW_REPLAY_CONTAINER);

			var refName = string.Format(RAW_REPLAY_REF_NAME, id);

			var blob = container.GetBlockBlobReference(refName);

			await blob.UploadFromByteArrayAsync(data, 0, data.Length);
		}

		public async Task<bool> RawReplayExists(ulong id)
		{
			if (id == 0)
				throw new ArgumentOutOfRangeException(nameof(id));

			var container = await GetContainer(RAW_REPLAY_CONTAINER);

			var refName = string.Format(RAW_REPLAY_REF_NAME, id);

			var blob = container.GetBlockBlobReference(refName);

			return await blob.ExistsAsync();
		}

		public async Task StoreParsedReplay(ulong id, string json)
		{
			if (id == 0)
				throw new ArgumentOutOfRangeException(nameof(id));

			if (json == null)
				throw new ArgumentNullException(nameof(json));

			var container = await GetContainer(PARSED_REPLAY_CONTAINER);

			var refName = string.Format(PARSED_REPLAY_REF_NAME, id);

			var blob = container.GetBlockBlobReference(refName);

			await blob.UploadTextAsync(json);
		}

		public async Task<bool> ParsedReplayExists(ulong id)
		{
			if (id == 0)
				throw new ArgumentOutOfRangeException(nameof(id));

			var container = await GetContainer(PARSED_REPLAY_CONTAINER);

			var refName = string.Format(PARSED_REPLAY_REF_NAME, id);

			var blob = container.GetBlockBlobReference(refName);

			return await blob.ExistsAsync();
		}
	}
}