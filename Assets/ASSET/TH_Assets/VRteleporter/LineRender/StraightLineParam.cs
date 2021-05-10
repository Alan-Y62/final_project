using UnityEngine;

public class StraightLineParam : MonoBehaviour, IGenLine{

	public LineRenderer line;

	[Range(0,250)]
	public int num = 10;

	public virtual void genLine(Vector3 start, Vector3 end){
		line.SetVertexCount(num);

		for(int i = 0; i < num; i++){
			Vector3 newPos = Vector3.Lerp(start, end,(float)i/num);// Mathf.Lerp(start.y, end.y,(float)i/num);
			line.SetPosition(i, newPos);
		}	
	}
}