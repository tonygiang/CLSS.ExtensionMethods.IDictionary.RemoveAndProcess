// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IDictionaryRemoveAndProcess
  {
    /// <inheritdoc cref="RemoveAndProcess{T, TKey, TValue, TResult}(T, TKey, Func{TValue, TResult})"/>
    public static T RemoveAndProcess<T, TKey, TValue>(this T source,
      TKey key,
      Action<TValue> processingAction)
      where T : IDictionary<TKey, TValue>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[key];
      source.Remove(key);
      processingAction(element);
      return source;
    }

    /// <inheritdoc cref="RemoveAndProcess{T, TKey, TValue, TResult}(T, TKey, Func{TValue, TResult})"/>
    public static IDictionary<TKey, TValue> RemoveAndProcess<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      Action<TValue> processingAction)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[key];
      source.Remove(key);
      processingAction(element);
      return source;
    }

    /// <summary>
    /// Takes the element associated with the specified key, removes that
    /// element's key from the source collection and passes the removed element
    /// to the specified delegate.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IDictionary{TKey, TValue}"/>
    /// to remove element from.</typeparam>
    /// <typeparam name="TKey"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <typeparam name="TValue"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TValue']"/></typeparam>
    /// <typeparam name="TResult">The return type of
    /// <paramref name="processingAction"/>.</typeparam>
    /// <param name="source">The <see cref="IDictionary{TKey, TValue}"/> to
    /// remove element.</param>
    /// <param name="key">
    /// <inheritdoc cref="IDictionary{TKey, TValue}.Remove(TKey)"
    /// path="/param[@name='key']"/></param>
    /// <param name="processingAction">The action that will be executed with the
    /// removed value as its argument.</param>
    /// <returns>The source collection.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or
    /// <paramref name="processingAction"/> is null.</exception>
    public static T RemoveAndProcess<T, TKey, TValue, TResult>(this T source,
      TKey key,
      Func<TValue, TResult> processingAction)
      where T : IDictionary<TKey, TValue>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[key];
      source.Remove(key);
      processingAction(element);
      return source;
    }

    /// <inheritdoc cref="RemoveAndProcess{T, TKey, TValue, TResult}(T, TKey, Func{TValue, TResult})"/>
    public static IDictionary<TKey, TValue> RemoveAndProcess<TKey, TValue, TResult>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      Func<TValue, TResult> processingAction)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (processingAction == null)
        throw new ArgumentNullException("processingAction");
      var element = source[key];
      source.Remove(key);
      processingAction(element);
      return source;
    }
  }
}