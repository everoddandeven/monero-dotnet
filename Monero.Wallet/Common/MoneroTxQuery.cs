﻿
using Monero.Common;

namespace Monero.Wallet.Common
{
    public class MoneroTxQuery : MoneroTxWallet
    {
        private bool? isOutgoing;
        private bool? isIncoming;
        private List<string> hashes = [];
        private bool? hasPaymentId;
        private List<string> paymentIds = [];
        private ulong? height;
        private ulong? minHeight;
        private ulong? maxHeight;
        private bool? includeOutputs;
        protected MoneroTransferQuery? transferQuery;
        protected MoneroOutputQuery? inputQuery;
        protected MoneroOutputQuery? outputQuery;

        public MoneroTxQuery()
        {

        }

        public MoneroTxQuery(MoneroTxQuery query) : base(query)
        {
            this.isOutgoing = query.isOutgoing;
            this.isIncoming = query.isIncoming;
            if (query.hashes != null) this.hashes = new List<string>(query.hashes);
            this.hasPaymentId = query.hasPaymentId;
            if (query.paymentIds != null) this.paymentIds = new List<string>(query.paymentIds);
            this.height = query.height;
            this.minHeight = query.minHeight;
            this.maxHeight = query.maxHeight;
            this.includeOutputs = query.includeOutputs;
            if (query.transferQuery != null) this.SetTransferQuery(new MoneroTransferQuery(query.transferQuery));
            if (query.inputQuery != null) this.SetInputQuery(new MoneroOutputQuery(query.inputQuery));
            if (query.outputQuery != null) this.SetOutputQuery(new MoneroOutputQuery(query.outputQuery));
        }

        public override MoneroTxQuery Clone()
        {
            return new MoneroTxQuery(this);
        }

        public override MoneroTxQuery SetIsLocked(bool? isLocked)
        {
            base.SetIsLocked(isLocked);
            return this;
        }

        public override bool? IsOutgoing()
        {
            return isOutgoing;
        }

        public override MoneroTxQuery SetIsOutgoing(bool? isOutgoing)
        {
            this.isOutgoing = isOutgoing;
            return this;
        }

        public override bool? IsIncoming()
        {
            return isIncoming;
        }

        public override MoneroTxQuery SetIsIncoming(bool? isIncoming)
        {
            this.isIncoming = isIncoming;
            return this;
        }

        public override MoneroTxQuery SetHash(string hash)
        {
            base.SetHash(hash);
            return SetHashes([hash]);
        }

        public List<string> GetHashes()
        {
            return hashes;
        }

        public MoneroTxQuery SetHashes(List<string> hashes)
        {
            this.hashes = hashes;
            return this;
        }

        public bool? HasPaymentId()
        {
            return hasPaymentId;
        }

        public MoneroTxQuery SetHasPaymentId(bool hasPaymentId)
        {
            this.hasPaymentId = hasPaymentId;
            return this;
        }

        public List<string> GetPaymentIds()
        {
            return paymentIds;
        }

        public MoneroTxQuery SetPaymentIds(List<string> paymentIds)
        {
            this.paymentIds = paymentIds;
            return this;
        }

        public MoneroTxQuery SetPaymentId(string paymentId)
        {
            return SetPaymentIds([paymentId]);
        }

        public ulong? GetHeight()
        {
            return height;
        }

        public MoneroTxQuery SetHeight(ulong height)
        {
            this.height = height;
            return this;
        }

        public ulong? GetMinHeight()
        {
            return minHeight;
        }

        public MoneroTxQuery SetMinHeight(ulong minHeight)
        {
            this.minHeight = minHeight;
            return this;
        }

        public ulong? GetMaxHeight()
        {
            return maxHeight;
        }

        public MoneroTxQuery SetMaxHeight(ulong maxHeight)
        {
            this.maxHeight = maxHeight;
            return this;
        }

        public override MoneroTxQuery SetUnlockTime(ulong? unlockTime)
        {
            base.SetUnlockTime(unlockTime == null ? null : unlockTime);
            return this;
        }

        public bool? GetIncludeOutputs()
        {
            return includeOutputs;
        }

        public MoneroTxQuery SetIncludeOutputs(bool includeOutputs)
        {
            this.includeOutputs = includeOutputs;
            return this;
        }

        public MoneroTransferQuery? GetTransferQuery()
        {
            return transferQuery;
        }

        public MoneroTxQuery SetTransferQuery(MoneroTransferQuery transferQuery)
        {
            this.transferQuery = transferQuery;
            if (transferQuery != null) transferQuery.SetTxQuery(this);
            return this;
        }

        public MoneroOutputQuery? GetInputQuery()
        {
            return inputQuery;
        }

        public MoneroTxQuery SetInputQuery(MoneroOutputQuery inputQuery)
        {
            this.inputQuery = inputQuery;
            if (inputQuery != null) inputQuery.SetTxQuery(this);
            return this;
        }

        public MoneroOutputQuery? GetOutputQuery()
        {
            return outputQuery;
        }

        public MoneroTxQuery SetOutputQuery(MoneroOutputQuery outputQuery)
        {
            this.outputQuery = outputQuery;
            if (outputQuery != null) outputQuery.SetTxQuery(this);
            return this;
        }

        public bool MeetsCriteria(MoneroTx tx)
        {
            throw new NotImplementedException("MoneroTxQuery.MeetsCriteria(MoneroTx tx) is not implemented yet. Please implement this method to filter transactions based on the query criteria.");
        }

        public bool MeetsCriteria(MoneroTxWallet tx)
        {
            throw new NotImplementedException("MoneroTxQuery.MeetsCriteria(MoneroTxWallet tx) is not implemented yet. Please implement this method to filter transactions based on the query criteria.");
        }
    }
}
