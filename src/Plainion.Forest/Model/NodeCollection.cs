﻿using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Plainion.Collections;

namespace Plainion.Forest.Model
{
    internal class NodeCollection : ObservableCollection<Node>, IObservableEnumerable<Node>
    {
        private Node myParent;

        public NodeCollection( Node parent )
        {
            myParent = parent;
        }

        protected override void OnCollectionChanged( NotifyCollectionChangedEventArgs e )
        {
            if( e.Action != NotifyCollectionChangedAction.Move )
            {
                SetParent( e.NewItems, myParent );
                SetParent( e.OldItems, null );
            }

            base.OnCollectionChanged( e );
        }

        private void SetParent( IList items, Node parent )
        {
            if( items == null )
            {
                return;
            }

            foreach( Node n in items )
            {
                n.Parent = parent;
            }
        }
    }
}
