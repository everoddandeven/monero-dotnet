﻿using Monero.Wallet;
using Monero.Wallet.Common;

namespace Monero.Test
{
    public class TestMoneroWalletLight : TestMoneroWalletCommon
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        protected override void CloseWallet(MoneroWallet wallet, bool save)
        {
            throw new NotImplementedException();
        }

        protected override MoneroWallet CreateWallet(MoneroWalletConfig config)
        {
            throw new NotImplementedException();
        }

        protected override List<string> GetSeedLanguages()
        {
            throw new NotImplementedException();
        }

        protected override MoneroWallet GetTestWallet()
        {
            throw new NotImplementedException();
        }

        protected override MoneroWallet OpenWallet(MoneroWalletConfig config)
        {
            throw new NotImplementedException();
        }
    }
}
