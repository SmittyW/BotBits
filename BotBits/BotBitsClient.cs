﻿using System;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Threading;

namespace BotBits
{
    public class BotBitsClient : ISchedulerHandle
    {
        // TODO: Physics (extension?)
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ISchedulerHandle _schedulerHandle;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly PackageLoader _packageLoader = new PackageLoader();

        public BotBitsClient() : this(BotServices.GetScheduler())
        {
        }

        internal BotBitsClient(ISchedulerHandle schedulerHandle)
        {
            this._schedulerHandle = schedulerHandle;

            DefaultExtension
                .LoadInto(this);
        }

        public SynchronizationContext SynchronizationContext
        {
            get { return _schedulerHandle.SynchronizationContext; }
        }

        internal T Get<T>() where T : Package<T>, new()
        {
            return this._packageLoader.Get<T>();
        }

        internal void Add(ComposablePartCatalog catalog, Action initialize)
        {
            this._packageLoader.AddPackages(this, catalog, initialize);
        }

        public void Dispose()
        {
            this._packageLoader.Dispose();
            this._schedulerHandle.Dispose();
        }

        private PackageLoader Packages
        {
            get { return this._packageLoader; }
        }
    }
}