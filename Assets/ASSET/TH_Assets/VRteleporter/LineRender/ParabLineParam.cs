using UnityEngine;
using System.Collections;

public class ParabLineParam : StraightLineParam, IGenLine{

	public float offY = 1;
	public float offX = 0;
	public float slopeIntensity = 25;
	public float window = 1;
	public float windowWidth = 1;
	[Tooltip("Intensity 2 - increases the intensity of the ARC. Direction is also (+)")]
	public float int2 = -1;
	public float b = 0;

	float InvParabola(float x, float xShift = 0, float yShift = 0){
		return int2 * Mathf.Pow(((x / slopeIntensity) * window - windowWidth) + xShift, 2) + b * x + yShift;
	}

	private float dist;

	public override void genLine(Vector3 start, Vector3 end){
		line.SetVertexCount(num);
		dist = Vector3.Distance(start,end);
		//line.SetPosition(0, start);

		float xStep = (end.x - start.x) / num;
		float zStep = (end.z - start.z) / num;
		//float yDiff = end.y - start.y;

		for (int i = 0; i < num; i++){
			//float y = Mathf.Sin(((float)i / num) * (Mathf.PI));
			float y = InvParabola(i, offX, offY);
			line.SetPosition(i, new Vector3(start.x + xStep * i, end.y + y, start.z + zStep * i));
		}
		//line.SetPosition(num - 1, end);
	}
}
