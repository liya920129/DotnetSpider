﻿using System;
using System.Text.RegularExpressions;
using DotnetSpider.Core;

namespace DotnetSpider.Extension.Model.Formatter
{
	/// <summary>
	/// 如果数值符合正则表达式则在数值后面追加指定的内容. 如采集到的内容为数字, 则在后面添加 "人"
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class RegexAppendFormatter : Formatter
	{
		/// <summary>
		/// 正则表达式
		/// </summary>
		public string Pattern { get; set; }

		/// <summary>
		/// 追加的内容
		/// </summary>
		public string AppendValue { get; set; }

		/// <summary>
		/// 实现数值的转化
		/// </summary>
		/// <param name="value">数值</param>
		/// <returns>被格式化后的数值</returns>
		protected override object FormateValue(object value)
		{
			var tmp = value.ToString();
			return Regex.IsMatch(tmp, Pattern) ? $"{tmp}{AppendValue}" : tmp;
		}

		/// <summary>
		/// 校验参数是否设置正确
		/// </summary>
		protected override void CheckArguments()
		{
			if (string.IsNullOrWhiteSpace(Pattern))
			{
				throw new SpiderException("Pattern should not be null or empty");
			}

			if (string.IsNullOrWhiteSpace(AppendValue))
			{
				throw new SpiderException("Append should not be null or empty");
			}
		}
	}
}
