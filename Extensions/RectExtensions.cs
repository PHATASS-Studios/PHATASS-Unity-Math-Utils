﻿using UnityEngine;

using static PHATASS.Utils.Extensions.IComparableExtensions;

namespace PHATASS.Utils.Extensions
{
	//methods for Rect manipulation
	public static class RectExtensions
	{
	//Rect creation methods
		//Creates a new rect with given dimensions at target position
		public static Rect ERectFromCenterAndSize (this Vector2 position, Vector3 size)
		{ return RectExtensions.ERectFromCenterAndSize(position, size.x, size.y); }
		public static Rect ERectFromCenterAndSize (this Vector2 position, Vector2 size)
		{ return RectExtensions.ERectFromCenterAndSize(position, size.x, size.y); }
		public static Rect ERectFromCenterAndSize (this Vector2 position, float width, float height)
		{
			return new Rect(
				x: position.x - (width / 2),
				y: position.y - (height / 2),
				width: width,
				height: height
			);
		}
		// Vector3 variants
		public static Rect ERectFromCenterAndSize (this Vector3 position, Vector3 size)
		{ return ((Vector2) position).ERectFromCenterAndSize(size.x, size.y); }
		public static Rect ERectFromCenterAndSize (this Vector3 position, Vector2 size)
		{ return ((Vector2) position).ERectFromCenterAndSize(size.x, size.y); }
		public static Rect ERectFromCenterAndSize (this Vector3 position, float width, float height)
		{ return ((Vector2) position).ERectFromCenterAndSize(width, height); }

		//Creates the smallest rect possible that contains given list of points
		public static Rect ERectFromPoints (this Vector2[] points)
		{
			//prepare given coordinates for sorting
			float[] xPositions = new float[points.Length];
			float[] yPositions = new float[points.Length];
			for (int i = 0, iLimit = points.Length; i < iLimit; i++)
			{
				xPositions[i] = points[i].x;
				yPositions[i] = points[i].y;
			}

			//determine the corners of the rect from the minimum and maximum values
			float xMin = xPositions.EMinimum();
			float xMax = xPositions.EMaximum();
			float yMin = yPositions.EMinimum();
			float yMax = yPositions.EMaximum();

			//create a Rect from its corners
			return Rect.MinMaxRect(
				xmin: xMin,
				xmax: xMax,
				ymin: yMin,
				ymax: yMax
			);
		}
	//ENDOF Rect creation methods

	//Rect clamping and trimming methods 
		//clamp a x/y position within a rect
		public static Vector2 EClampWithinRect (this Vector2 position, Rect outerRect)
		{
			return new Vector2
			(
				x: Mathf.Clamp(position.x, outerRect.xMin, outerRect.xMax),
				y: Mathf.Clamp(position.y, outerRect.yMin, outerRect.yMax)
			);
		}
		public static Vector3 EClampWithinRect (this Vector3 position, Rect outerRect)
		{
			return new Vector3
			(
				x: Mathf.Clamp(position.x, outerRect.xMin, outerRect.xMax),
				y: Mathf.Clamp(position.y, outerRect.yMin, outerRect.yMax),
				z: position.z
			);
		}

		//ensures innerRect bounds stay within outerRect by moving innerRect if protruding.
		//if innerRect dimensions exceed outerRect, they will be centered
		public static Rect EClampWithinRect (this Rect innerRect, Rect outerRect)
		{
			return new Rect (
				x: (innerRect.width <= outerRect.width)
					? //if innerRect is thinner than outerRect, clamp its position within outerRect
						Mathf.Clamp(					
							value: innerRect.x,
							min: outerRect.xMin,
							max: outerRect.xMax - innerRect.width
						)
					: //if innerRect is wider than outerRect, center their position
						outerRect.x - ((innerRect.width - outerRect.width) / 2),
				y: (innerRect.height <= outerRect.height)
					? //if innerRect is shorter than outerRect clamp its position
						Mathf.Clamp(
							value: innerRect.y,
							min: outerRect.yMin,
							max: outerRect.yMax - innerRect.height
						)
					: //if innerRect is taller than outerRect, center their position
						innerRect.y - ((innerRect.height - outerRect.width) / 2),
				width: innerRect.width,
				height: innerRect.height
			);
		}

		//truncates innerRect dimensions to fit outerRect. may return the same rect if already small enough.
		//only alters size, returned rect's position will be the same as innerRect's
		public static Rect ETrimRectSizeToRect (this Rect innerRect, Rect outerRect)
		{
			if (innerRect.width <= outerRect.width && innerRect.height <= outerRect.height)
			{ return innerRect; }
			return new Rect (
				x: innerRect.x,
				y: innerRect.y,
				width: Mathf.Clamp(innerRect.width, 0, outerRect.width),
				height: Mathf.Clamp(innerRect.height, 0, outerRect.height)
			);
		}

		//fits a rect within another, trimming its size 
		public static Rect ETrimAndClampRectWithinRect (this Rect innerRect, Rect outerRect)
		{
			return RectExtensions.EClampWithinRect(
				innerRect: innerRect.ETrimRectSizeToRect(outerRect),
				outerRect: outerRect
			);
		}
	//ENDOF Rect clamping and trimming methods

	//Rect interpolation and movement
		//moves a rect
		public static Rect EMoveRect (this Rect rect, Vector3 movement)
		{ return RectExtensions.EMoveRect(rect: rect, movement: (Vector2) movement); }
		public static Rect EMoveRect (this Rect rect, Vector2 movement)
		{
			rect.position = rect.position + movement;
			return rect;
		}
		
		//interpolates position and size
		public static Rect ELerpRect (this Rect from, Rect to, float positionLerpRate, float sizeLerpRate)
		{
			return RectExtensions.ERectFromCenterAndSize(
				position: Vector2.Lerp(from.center, to.center, positionLerpRate),
				width: Mathf.Lerp(from.width, to.width, sizeLerpRate),
				height: Mathf.Lerp(from.height, to.height, sizeLerpRate)
			);
		}
	//ENDOF Rect interpolation

	}
}