﻿/*
Copyright (c) 2019-2020 Integrative Software LLC
Created: 5/2019
Author: Pablo Carbonell
*/

namespace Integrative.Lara
{
    /// <summary>
    /// A generic element class for all elements that are not handled by specialized classes.
    /// </summary>
    /// <seealso cref="Element" />
    public sealed class GenericElement : Element
    {
        internal GenericElement(string tagName) : base(tagName)
        {
        }

        internal GenericElement(string tagName, params Node[] items) : base(tagName, items)
        {
        }
    }
}
