using System;
using NUnit.Framework;
using StuartHeathTools;
using UnityEngine;

public class UtilityTests
{
	#region FormatMoneyToKMB

	[Test]
	public void FormatMoneyToKMBSub1000()
	{
		Assert.AreEqual("576", Utility.FormatMoneyToKMB(576));
		Assert.AreEqual("576", Utility.FormatMoneyToKMB((long)576f));
		Assert.AreEqual("576", Utility.FormatMoneyToKMB(576L));
		Assert.AreEqual("-256", Utility.FormatMoneyToKMB(-256));
		Assert.AreEqual("-256", Utility.FormatMoneyToKMB((long)-256f));
		Assert.AreEqual("-256", Utility.FormatMoneyToKMB(-256L));
	}

	[Test]
	public void FormatMoneyToKMBk()
	{
		Assert.AreEqual("5.8K", Utility.FormatMoneyToKMB(5760));
		Assert.AreEqual("5.8K", Utility.FormatMoneyToKMB((long)5760f));
		Assert.AreEqual("5.8K", Utility.FormatMoneyToKMB(5760L));
		Assert.AreEqual("-2.56K", Utility.FormatMoneyToKMB(-2560));
		Assert.AreEqual("-2.6K", Utility.FormatMoneyToKMB((long)-2560f));
		Assert.AreEqual("-2.6K", Utility.FormatMoneyToKMB(-2560L));
	}

	[Test]
	public void FormatMoneyToKMBm()

	{
		Assert.AreEqual("5.76M", Utility.FormatMoneyToKMB(5760000));
		Assert.AreEqual("5.76M", Utility.FormatMoneyToKMB((long)5760000f));
		Assert.AreEqual("5.76M", Utility.FormatMoneyToKMB(5760000L));
		Assert.AreEqual("-2.56M", Utility.FormatMoneyToKMB(-2560000));
		Assert.AreEqual("-2.56M", Utility.FormatMoneyToKMB((long)-2560000f));
		Assert.AreEqual("-2.56M", Utility.FormatMoneyToKMB(-2560000L));
	}

	[Test]
	public void FormatMoneyToKMBb()
	{
		Assert.AreEqual("5.76B", Utility.FormatMoneyToKMB(5760000000));
		Assert.AreEqual("5.76B", Utility.FormatMoneyToKMB((long)5760000000f));
		Assert.AreEqual("5.76B", Utility.FormatMoneyToKMB(5760000000L));
		Assert.AreEqual("-2.56B", Utility.FormatMoneyToKMB(-2560000000));
		Assert.AreEqual("-2.56B", Utility.FormatMoneyToKMB((long)-2560000000f));
		Assert.AreEqual("-2.56B", Utility.FormatMoneyToKMB(-2560000000L));
	}
	

	
	#endregion

	[Test]
	public void IsNumericTypeFalse()
	{
		Assert.False(this.IsNumericType());
		Assert.False(new GameObject().IsNumericType());
		Assert.False(new object().IsNumericType());
	}

	[Test]
	public void IsNumericTypeTrue()
	{
		Assert.True(32.IsNumericType());
		Assert.True(32f.IsNumericType());
		Assert.True(32L.IsNumericType());
		Assert.True((-32f).IsNumericType());
		Assert.True((-32L).IsNumericType());
		Assert.True(0b1.IsNumericType());
		Assert.True(0x2.IsNumericType());
		Assert.True((-0x2).IsNumericType());
		Assert.True(((Int16)2).IsNumericType());
		Assert.True(((Int64)2).IsNumericType());
		Assert.True(32d.IsNumericType());
		Assert.True((-32d).IsNumericType());
		Assert.True(32m.IsNumericType());
		Assert.True((-32m).IsNumericType());
		Assert.True((-32u).IsNumericType());
		Assert.True(32u.IsNumericType());
		




	}
}