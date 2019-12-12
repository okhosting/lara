﻿/*
Copyright (c) 2019 Integrative Software LLC
Created: 12/2019
Author: Pablo Carbonell
*/

using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Integrative.Lara.Middleware
{
    [DataContract]
    class FormFile : IFormFile
    {
        [DataMember]
        public string ContentType { get; set; } = string.Empty;

        [DataMember]
        public string ContentDisposition { get; set; } = string.Empty;

        [DataMember]
        public long Length { get; set; }

        [DataMember]
        public string Name { get; set; } = string.Empty;

        [DataMember]
        public string FileName { get; set; } = string.Empty;

        [DataMember]
        public byte[] Bytes { get; set; } = Array.Empty<byte>();

        readonly HeaderDictionary _headers = new HeaderDictionary();
        public IHeaderDictionary Headers => _headers;

        public void CopyTo(Stream target)
        {
            target.Write(Bytes, 0, Bytes.Length);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return target.WriteAsync(Bytes, 0, Bytes.Length, cancellationToken);
        }

        public Stream OpenReadStream()
        {
            return new MemoryStream(Bytes);
        }
    }
}
