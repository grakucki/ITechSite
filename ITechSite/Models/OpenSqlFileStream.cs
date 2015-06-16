using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{
public class OpenSqlFileStream : Stream, IDisposable
{
    private SqlFileStream Stream { get; set; }
    private DbConnection Connection { get; set; }
    private DbTransaction Transaction { get; set; }

    public OpenSqlFileStream(SqlFileStream stream, DbConnection connection, DbTransaction transaction) :
        base()
    {
        Stream = stream;
        Connection = connection;
        Transaction = transaction;
    }

    public new void Dispose()
    {
        Transaction.Dispose();
        Connection.Dispose();
        Stream.Dispose();
    }

    public override bool CanRead
    {
        get { return Stream.CanRead; }
    }

        public override bool CanSeek
        {
            get { return Stream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return Stream.CanWrite; }
        }

        public override void Flush()
        {
            Stream.Flush();
        }

        public override long Length
        {
            get { return Stream.Length; }
        }

        public override long Position
        {
            get
            {
                return Stream.Position;
            }
            set
            {
                Stream.Position = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Stream.Write(buffer, offset, count);
        }
    }
}