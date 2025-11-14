using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MyWorkoutLog.Services
{

    public class ObservableDictionary<TKey, TValue> :
        IDictionary<TKey, TValue>,
        INotifyCollectionChanged,
        INotifyPropertyChanged
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new();

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        // for implementing dictionary
        public TValue this[TKey key]
        {
            get => _dictionary[key];
            set
            {
                _dictionary[key] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                    NotifyCollectionChangedAction.Replace, value, key));
                OnPropertyChanged(nameof(Count));
            }
        }

        public ICollection<TKey> Keys => _dictionary.Keys;
        public ICollection<TValue> Values => _dictionary.Values;
        public int Count => _dictionary.Count;
        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Add,
                new KeyValuePair<TKey, TValue>(key, value)));
            OnPropertyChanged(nameof(Count));
        }

        public bool Remove(TKey key)
        {
            if (_dictionary.TryGetValue(key, out var value))
            {
                bool removed = _dictionary.Remove(key);
                if (removed)
                {
                    OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                        NotifyCollectionChangedAction.Remove,
                        new KeyValuePair<TKey, TValue>(key, value)));
                    OnPropertyChanged(nameof(Count));
                }
                return removed;
            }
            return false;
        }

        public void Clear()
        {
            _dictionary.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Reset));
            OnPropertyChanged(nameof(Count));
        }

        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);
        public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);
        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
        public bool Contains(KeyValuePair<TKey, TValue> item) => _dictionary.Contains(item);
        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            => ((IDictionary<TKey, TValue>)_dictionary).CopyTo(array, arrayIndex);

       
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();

        
        IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();

        // for notifying ui about changes
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
            => CollectionChanged?.Invoke(this, args);

        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
