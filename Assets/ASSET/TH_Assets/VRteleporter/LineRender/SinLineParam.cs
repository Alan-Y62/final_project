using UnityEngine;
using System.Collections;

public class SinLineParam : StraightLineParam, IGenLine{
	public float xScale = 1;
	public float yScale = 1;
	public float offset = 0;

	public float sin(float x){
		return yScale * Mathf.Sin((x + offset) * xScale);
	}

	public void genLine(Vector3 start, Vector3 end){
		line.SetVertexCount(num);
		//line.SetPosition(0, start);

		float xStep = (end.x - start.x) / num;
		float zStep = (end.z - start.z) / num;
		//float yDiff = end.y - start.y;

		for (int i = 0; i < num; i++){
			//float y = Mathf.Sin(((float)i / num) * (Mathf.PI));
			float y = sin(i);
			line.SetPosition(i, new Vector3(start.x + xStep * i, end.y + y, start.z + zStep * i));
		}
		//line.SetPosition(num - 1, end);
	}
}
