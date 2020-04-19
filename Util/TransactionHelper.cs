using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Util
{
    public class TransactionHelper
    {

        /// <summary>
        /// Cria uma nova transaction, com configurações pré-definidas diferentes da Default
        /// </summary>
        /// <returns></returns>
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }

        /// <summary>
        /// Cria uma nova transaction, com configurações pré-definidas diferentes da Default
        /// </summary>
        /// <returns></returns>
        public static TransactionScope CreateTransactionScopeAsync()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = TransactionManager.MaximumTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions,TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
