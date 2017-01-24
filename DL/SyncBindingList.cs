using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DL
{
    public class SyncBindingList<T> : BindingList<T>
    {
        private readonly SynchronizationContext _syncContext;
        public SyncBindingList()
        {
            _syncContext = SynchronizationContext.Current;
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_syncContext != null)
                _syncContext.Send(_ => base.OnListChanged(e), null);
            else
                base.OnListChanged(e);
        }
    }
}
