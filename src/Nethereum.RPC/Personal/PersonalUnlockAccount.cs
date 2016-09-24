using System;
using System.Threading.Tasks;
using EdjCase.JsonRpc.Core;
using Nethereum.Hex.HexTypes;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Eth;

namespace Nethereum.RPC.Personal
{
    /// <Summary>
    ///     personal_unlockAccount
    ///     Unlock an account
    ///     Parameters
    ///     string, address of the account to unlock
    ///     string, passphrase of the account to unlock (optional in console, user will be prompted)
    ///     integer, unlock account for duration seconds (optional)
    ///     Return
    ///     boolean indication if the account was unlocked
    ///     Example
    ///     personal.unlockAccount(eth.coinbase, "mypasswd", 300)
    /// </Summary>
    [Obsolete("Unsafe and geth specific (e.g. not compatible with Parity). Use PersonalSignAndSendTransaction instead.")]
    public class PersonalUnlockAccount : RpcRequestResponseHandler<bool>
    {
        public PersonalUnlockAccount(IClient client) : base(client, ApiMethods.personal_unlockAccount.ToString())
        {
        }

        public async Task<bool> SendRequestAsync(string address, string passPhrase, HexBigInteger durationInSeconds,
            object id = null)
        {
            return await base.SendRequestAsync(id, address, passPhrase, durationInSeconds).ConfigureAwait(false);
        }

        public async Task<bool> SendRequestAsync(EthCoinBase coinbaseRequest, string passPhrase,
            HexBigInteger durationInSeconds,
            object id = null)
        {
            return
                await
                    base.SendRequestAsync(id, await coinbaseRequest.SendRequestAsync(), passPhrase, durationInSeconds)
                        .ConfigureAwait(false);
        }

        public RpcRequest BuildRequest(string address, string passPhrase, HexBigInteger durationInSeconds,
            object id = null)
        {
            return base.BuildRequest(id, address, passPhrase, durationInSeconds);
        }
    }
}