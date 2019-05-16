﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

using Integrative.Lara.DOM;
using System.Runtime.Serialization;

namespace Integrative.Lara.Delta
{
    [DataContract]
    sealed class SetIdDelta : BaseDelta
    {
        [DataMember]
        public ElementLocator Locator { get; set; }

        [DataMember]
        public string NewId { get; set; }

        public SetIdDelta() : base(DeltaType.SetId)
        {
        }

        public static void Enqueue(Element element, string newValue)
        {
            if (element.QueueOpen)
            {
                var locator = ElementLocator.FromElement(element);
                element.Document.Enqueue(new SetIdDelta
                {
                    Locator = locator,
                    NewId = newValue
                });
            }
        }
    }
}