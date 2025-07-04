﻿
namespace Monero.Wallet.Common
{
    public class MoneroDestination
    {
        private string? _address;
        private ulong? _amount;

        public MoneroDestination(string? address = null, ulong? amount = null)
        {
            _address = address;
            _amount = amount;
        }

        public MoneroDestination(MoneroDestination destination)
        {
            _address = destination._address;
            _amount = destination._amount;
        }

        public MoneroDestination Clone() { return new MoneroDestination(this); }

        public string GetAddress()
        {
            return _address;
        }

        public MoneroDestination SetAddress(string? address)
        {
            _address = address;
            return this;
        }

        public ulong? GetAmount()
        {
            return _amount;
        }

        public MoneroDestination SetAmount(ulong? amount)
        {
            _amount = amount;
            return this;
        }
    }
}
