﻿using Monero.Common;
using Monero.Daemon.Common;

namespace Monero.Daemon
{
    public abstract class MoneroDaemonDefault : MoneroDaemon
    {
        protected List<MoneroDaemonListener> _listeners = [];
        protected Dictionary<ulong, MoneroBlockHeader> _cachedHeaders = [];

        public virtual void AddListener(MoneroDaemonListener listener)
        {
            lock (_listeners)
            {
                _listeners.Add(listener);
            }
        }

        public abstract MoneroDaemonUpdateCheckResult CheckForUpdate();

        public abstract MoneroDaemonUpdateDownloadResult DownloadUpdate();

        public abstract MoneroDaemonUpdateDownloadResult DownloadUpdate(string path);

        public abstract void FlushTxPool();

        public abstract void FlushTxPool(List<string> txHashes);

        public abstract List<string> GetAltBlockHashes();

        public abstract List<MoneroAltChain> GetAltChains();

        public abstract MoneroBlock GetBlockByHash(string blockHash);

        public abstract MoneroBlock GetBlockByHeight(long blockHeight);

        public abstract string GetBlockHash();

        public abstract List<string> GetBlockHashes(List<string> blockHashes, long startHeight);

        public abstract MoneroBlockHeader GetBlockHeaderByHash(string blockHash);

        public abstract MoneroBlockHeader GetBlockHeaderByHeight(long blockHeight);

        public abstract List<MoneroBlockHeader> GetBlockHeadersByRange(long startHeight, long endHeight);

        public abstract List<MoneroBlock> GetBlocksByHash(List<string> blockHashes, long startHeight, bool prune);

        public abstract List<MoneroBlock> GetBlocksByHeight(List<long> blockHeights);

        public abstract List<MoneroBlock> GetBlocksByRange(long startHeight, long endHeight);

        public abstract List<MoneroBlock> GetBlocksByRangeChunked(long startHeight, long endHeight);

        public abstract MoneroBlockTemplate GetBlockTemplate(string walletAddress, int? reserveSize = null);

        public abstract int GetDownloadLimit();

        public abstract MoneroFeeEstimate GetFeeEstimate(int? graceBlocks = null);

        public abstract MoneroHardForkInfo GetHardForkInfo();

        public abstract long GetHeight();

        public abstract MoneroDaemonInfo GetInfo();

        public virtual MoneroKeyImage.SpentStatus GetKeyImageSpentStatus(string keyImage)
        {
            return GetKeyImageSpentStatuses([keyImage])[0];
        }

        public abstract List<MoneroKeyImage.SpentStatus> GetKeyImageSpentStatuses(List<string> keyImage);

        public abstract List<MoneroPeer> GetKnownPeers();

        public abstract MoneroBlockHeader GetLastBlockHeader();

        public virtual List<MoneroDaemonListener> GetListeners()
        {
            return [.. _listeners];
        }

        public abstract MoneroMiningStatus GetMiningStatus();

        public abstract List<MoneroOutputDistributionEntry> GetOutputDistribution(List<long> amounts, bool isCumulative, long startHeight, long endHeight);

        public abstract List<MoneroOutputHistogramEntry> GetOutputHistogram(List<long> amounts, int minCount, int maxCount, bool isUnlocked, int recentCutoff);

        public abstract List<MoneroOutput> GetOutputs(List<MoneroOutput> outputs);

        public abstract List<MoneroBan> GetPeerBans();

        public abstract List<MoneroPeer> GetPeers();

        public abstract MoneroDaemonSyncInfo GetSyncInfo();

        public abstract MoneroTx GetTx(string txHash, bool prune = false);

        public abstract string GetTxHex(string txHash, bool prune = false);

        public abstract List<string> GetTxHexes(List<string> txHashes, bool prune = false);

        public abstract List<MoneroTx> GetTxPool();

        public abstract List<string> GetTxPoolHashes();

        public abstract MoneroTxPoolStats GetTxPoolStats();

        public abstract List<MoneroTx> GetTxs(List<string> txHashes, bool prune = false);

        public abstract int GetUploadLimit();

        public abstract MoneroVersion GetVersion();

        public abstract bool IsTrusted();

        public abstract MoneroPruneResult PruneBlockchain(bool check);

        public virtual void RelayTxByHash(string txHash)
        {
            RelayTxsByHash([txHash]);
        }

        public abstract void RelayTxsByHash(List<string> txHashes);

        public virtual void RemoveListener(MoneroDaemonListener listener)
        {
            lock(_listeners)
            {
                _listeners.Remove(listener);
            }
        }

        public abstract void ResetDownloadLimit();

        public abstract void ResetUploadLimit();

        public abstract void SetDownloadLimit(int limit);

        public abstract void SetIncomingPeerLimit(int limit);

        public abstract void SetOutgoingPeerLimit(int limit);

        public virtual void SetPeerBan(MoneroBan ban)
        {
            SetPeerBans([ban]);
        }

        public abstract void SetPeerBans(List<MoneroBan> bans);

        public abstract void SetUploadLimit(int limit);

        public abstract void StartMining(string address, long numThreads, bool isBackground, bool ignoreBattery);

        public abstract void Stop();

        public abstract void StopMining();

        public virtual void SubmitBlock(string blockBlob)
        {
            SubmitBlocks([blockBlob]);
        }

        public abstract void SubmitBlocks(List<string> blockBlobs);

        public abstract MoneroSubmitTxResult SubmitTxHex(string txHex, bool doNotRelay = false);

        public abstract MoneroBlockHeader WaitForNextBlockHeader();
    }
}
