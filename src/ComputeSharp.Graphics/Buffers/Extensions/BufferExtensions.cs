﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using ComputeSharp.Graphics;
using ComputeSharp.Graphics.Buffers;

namespace ComputeSharp
{
    /// <summary>
    /// A <see langword="class"/> with extension methods for the <see cref="GraphicsDevice"/> type to allocate buffers
    /// </summary>
    public static class BufferExtensions
    {
        /// <summary>
        /// Allocates a new read write buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="size">The size of the buffer to allocate</param>
        /// <returns>A zeroed <see cref="ReadWriteBuffer{T}"/> instance of size <paramref name="size"/></returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadWriteBuffer<T> AllocateReadWriteBuffer<T>(this GraphicsDevice device, int size) where T : unmanaged
        {
            return new ReadWriteBuffer<T>(device, size);
        }

        /// <summary>
        /// Allocates a new read write buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="array">The input <typeparamref name="T"/> array with the data to copy on the allocated buffer</param>
        /// <returns>A read write <see cref="ReadWriteBuffer{T}"/> instance with the contents of the input array</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadWriteBuffer<T> AllocateReadWriteBuffer<T>(this GraphicsDevice device, T[] array) where T : unmanaged
        {
            return device.AllocateReadWriteBuffer(array.AsSpan());
        }

        /// <summary>
        /// Allocates a new read write buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="array">The input 2D <typeparamref name="T"/> array with the data to copy on the allocated buffer</param>
        /// <returns>A read write <see cref="ReadWriteBuffer{T}"/> instance with the contents of the input 2D array</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadWriteBuffer<T> AllocateReadWriteBuffer<T>(this GraphicsDevice device, T[,] array) where T : unmanaged
        {
            fixed (T* p = array)
            {
                Span<T> span = new Span<T>(p, array.Length);
                return device.AllocateReadWriteBuffer(span);
            }
        }

        /// <summary>
        /// Allocates a new read write buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="span">The input <see cref="Span{T}"/> with the data to copy on the allocated buffer</param>
        /// <returns>A read write <see cref="ReadWriteBuffer{T}"/> instance with the contents of the input <see cref="Span{T}"/></returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadWriteBuffer<T> AllocateReadWriteBuffer<T>(this GraphicsDevice device, Span<T> span) where T : unmanaged
        {
            ReadWriteBuffer<T> buffer = new ReadWriteBuffer<T>(device, span.Length);
            buffer.SetData(span);

            return buffer;
        }

        /// <summary>
        /// Allocates a new constant buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="array">The input <typeparamref name="T"/> array with the data to copy on the allocated buffer</param>
        /// <returns>A constant <see cref="ReadOnlyBuffer{T}"/> instance with the contents of the input array</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyBuffer<T> AllocateConstantBuffer<T>(this GraphicsDevice device, T[] array) where T : unmanaged
        {
            return device.AllocateConstantBuffer(array.AsSpan());
        }

        /// <summary>
        /// Allocates a new constant buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="array">The input 2D <typeparamref name="T"/> array with the data to copy on the allocated buffer</param>
        /// <returns>A constant <see cref="ReadOnlyBuffer{T}"/> instance with the contents of the input 2D array</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe ReadOnlyBuffer<T> AllocateConstantBuffer<T>(this GraphicsDevice device, T[,] array) where T : unmanaged
        {
            fixed (T* p = array)
            {
                Span<T> span = new Span<T>(p, array.Length);
                return device.AllocateConstantBuffer(span);
            }
        }

        /// <summary>
        /// Allocates a new constant buffer with the specified parameters
        /// </summary>
        /// <typeparam name="T">The type of items to store in the buffer</typeparam>
        /// <param name="device">The <see cref="GraphicsDevice"/> instance to use to allocate the buffer</param>
        /// <param name="span">The input <see cref="Span{T}"/> with the data to copy on the allocated buffer</param>
        /// <returns>A constant <see cref="ReadOnlyBuffer{T}"/> instance with the contents of the input <see cref="Span{T}"/></returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyBuffer<T> AllocateConstantBuffer<T>(this GraphicsDevice device, Span<T> span) where T : unmanaged
        {
            ReadOnlyBuffer<T> buffer = new ReadOnlyBuffer<T>(device, span.Length);
            buffer.SetData(span);

            return buffer;
        }
    }
}