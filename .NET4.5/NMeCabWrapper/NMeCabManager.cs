using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;

namespace NMeCabWrapper
{
	public class NMeCabManager
	{
		Assembly nmecabDll;
		readonly Type NMeCab_MeCabParam;
		readonly Type NMeCab_MeCabTagger;
		readonly Type NMeCab_MeCabLatticeLevel;
		readonly Type NMeCab_MeCabNodeStat;

		public NMeCabManager(string mecabDllPath)
		{
			nmecabDll = Assembly.LoadFile(mecabDllPath);

			NMeCab_MeCabParam = nmecabDll.GetType("NMeCab.MeCabParam", true, false);
			NMeCab_MeCabTagger = nmecabDll.GetType("NMeCab.MeCabTagger", true, false);
			NMeCab_MeCabLatticeLevel = nmecabDll.GetType("NMeCab.MeCabLatticeLevel", true, false);
			NMeCab_MeCabNodeStat = nmecabDll.GetType("NMeCab.MeCabNodeStat", true, false);
		}

		public NMeCabManager(FileInfo mecabDll)
			: this(mecabDll.FullName)
		{

		}

		public IMeCabParam CreateMeCabParam()
		{
			var o = NMeCab_MeCabParam.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
			return o.ActLike<IMeCabParam>();
		}

		public IMeCabTagger CreateMeCabTagger(IMeCabParam param)
		{
			var undo = param.UndoActLike();

			var mi = NMeCab_MeCabTagger.GetMethod("Create", new Type[] { NMeCab_MeCabParam });

			var obj = mi.Invoke(null, new object[] { undo });
			return obj.ActLike<IMeCabTagger>();
		}

		public object LatticeLevel(string labelString)
		{
			var o2 = NMeCab_MeCabLatticeLevel.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

			return Enum.Parse(NMeCab_MeCabLatticeLevel, labelString);
		}

		public object MeCabNodeStat(string labelString)
		{
			return Enum.Parse(NMeCab_MeCabNodeStat, labelString);
		}
	}
}
