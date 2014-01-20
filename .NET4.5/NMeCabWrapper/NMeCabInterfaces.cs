using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;

namespace NMeCabWrapper
{
	public interface IMeCabParam
	{
		bool AllMorphs { get; set; }
		bool AlloCateSentence { get; set; }
		string BosFeature { get; set; }
		int CostFactor { get; set; }
		string DicDir { get; set; }
		dynamic LatticeLevel { get; }
		int MaxGroupingSize { get; set; }
		string OutputFormatType { get; set; }
		bool Partial { get; set; }
		string RcFile { get; set; }
		float Theta { get; set; }
		string UnkFeature { get; set; }
		string[] UserDic { get; set; }

		void Load(string path);
		void LoadDicRC();
	}


	public interface IMeCabTagger : IDisposable
	{
		bool Partial { get; set; }
		float Theta { get; set; }
		dynamic LatticeLevel { get; }
		bool AllMorphs { get; set; }
		string OutPutFormatType { get; set; }
		string Parse(string str);
		IMeCabNode ParseToNode(string str);
		IEnumerable<IMeCabNode> ParseNBestToNode(string str);
		string ParseNBest(int n, string str);
		void Dispose();
	}

	public interface IMeCabNode
	{
		IMeCabNode Prev { get; set; }
		IMeCabNode Next { get; set; }
		IMeCabNode ENext { get; set; }
		IMeCabNode BNext { get; set; }
		string Surface { get; set; }
		string Feature { get; set; }
		int Length { get; set; }
		int RLength { get; set; }
		ushort RCAttr { get; set; }
		ushort LCAttr { get; set; }
		ushort PosId { get; set; }
		uint CharType { get; set; }
		dynamic Stat { get; }
		bool IsBest { get; set; }
		float Alpha { get; set; }
		float Beta { get; set; }
		float Prob { get; set; }
		short WCost { get; set; }
		long Cost { get; set; }
		int BPos { get; set; }
		int EPos { get; set; }
	}

	public static class NMeCabWrapperExtension
	{
		public static void SetLatticeLevel(this IMeCabParam param, string label, NMeCabManager context)
		{
			var o = param.UndoActLike();
			Impromptu.InvokeSet(o, "LatticeLevel", context.LatticeLevel(label));
		}

		public static void SetLatticeLevel(this IMeCabTagger param, string label, NMeCabManager context)
		{
			var o = param.UndoActLike();
			Impromptu.InvokeSet(o, "LatticeLevel", context.LatticeLevel(label));
		}

		public static void SetStat(this IMeCabNode param, string label, NMeCabManager context)
		{
			var o = param.UndoActLike();
			Impromptu.InvokeSet(o, "Stat", context.MeCabNodeStat(label));
		}
	}
}
