using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SocialClub_Account_Checker
{
	// Token: 0x02000004 RID: 4
	internal class AsyncQueue<T>
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000231C File Offset: 0x0000051C
		public int Count
		{
			get
			{
				return this.concurrentQueue.Count;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002329 File Offset: 0x00000529
		public void Enqueue(T item)
		{
			this.concurrentQueue.Enqueue(item);
			this.semaphoreSlim.Release();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000032B4 File Offset: 0x000014B4
		public void EnqueueRange(ICollection<T> collection)
		{
			foreach (T item in collection)
			{
				this.concurrentQueue.Enqueue(item);
			}
			this.semaphoreSlim.Release(collection.Count);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003314 File Offset: 0x00001514
		public async Task<T> DequeueAsync()
		{
			T result;
			for (;;)
			{
				TaskAwaiter taskAwaiter = this.semaphoreSlim.WaitAsync().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				if (this.concurrentQueue.IsEmpty)
				{
					break;
				}
				if (this.concurrentQueue.TryDequeue(out result))
				{
					goto IL_77;
				}
			}
			throw new InvalidOperationException("Queue empty.");
			IL_77:
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002343 File Offset: 0x00000543
		public bool Contains(T item)
		{
			return this.concurrentQueue.Contains(item);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002351 File Offset: 0x00000551
		public AsyncQueue()
		{
			Class3.oswSa3wz9mgro();
			this.concurrentQueue = new ConcurrentQueue<T>();
			this.semaphoreSlim = new SemaphoreSlim(1);
			base..ctor();
		}

		// Token: 0x0400000D RID: 13
		private readonly ConcurrentQueue<T> concurrentQueue;

		// Token: 0x0400000E RID: 14
		private readonly SemaphoreSlim semaphoreSlim;
	}
}
