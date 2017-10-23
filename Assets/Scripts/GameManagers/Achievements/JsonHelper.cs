using System;
using System.Collections.Generic;
using UnityEngine;

namespace POCC
{
	/**
	 * This is a JSONHelper obtained form stackoverflow - it is currently not in use,
	 * but has been kept here as legacy in case we want to switch to reading in 
	 * achievements as JSON.
	 * 
	 * Reference: https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
	 */ 
	public static class JsonHelper
	{
		public static T[] FromJson<T>(string json)
		{
			Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
			return wrapper.Items;
		}

		public static string ToJson<T>(T[] array)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper);
		}

		public static string ToJson<T>(T[] array, bool prettyPrint)
		{
			Wrapper<T> wrapper = new Wrapper<T>();
			wrapper.Items = array;
			return JsonUtility.ToJson(wrapper, prettyPrint);
		}

		[Serializable]
		private class Wrapper<T>
		{
			public T[] Items;
		}
	}
}

