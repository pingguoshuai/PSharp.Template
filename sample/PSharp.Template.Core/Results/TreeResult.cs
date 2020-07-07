using System;
using System.Collections.Generic;
using System.Linq;
using Util;
using Util.Ui.Data;

namespace PSharp.Template.Core.Results
{
    public class TreeResult<TNode> where TNode : TreeDto<TNode>
    {
        private readonly IEnumerable<TNode> _data;

        private readonly List<TNode> _result;

        public TreeResult(IEnumerable<TNode> data)
        {
            _data = data;
            _result = new List<TNode>();
        }

        public List<TNode> GetResult()
        {
            if (_data == null)
                return _result;
            return ResolveTree(Guid.Empty);
        }

        private List<TNode> ResolveTree(Guid pid)
        {
            return _data.Where(r => r.ParentId.ToGuid() == pid).Select(r =>
            {
                r.Children = ResolveTree(r.Id.ToGuid());
                return r;
            }).ToList();
        }
    }
}
