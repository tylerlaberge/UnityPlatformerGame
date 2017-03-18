    using UnityEngine;
     
    public class SmoothFollow : MonoBehaviour
    {
        #region Public Properties
	    public float distance = 10.0f;
	    public float SMOOTH_TIME = 0.3f;
	    public bool LockX;
	    public bool LockY;
	    public bool LockZ;
	    public bool useSmoothing;
	    public bool useYLimit;
	    public float yLimit;
	    public Transform target;
        #endregion
     
        #region Private Properties
	    private Transform thisTransform;
	    private Vector3 velocity;
        #endregion
	    
	    void Start()
	    {
	    }
     
	    private void Awake()
	    {
		    thisTransform = transform;
		    velocity = new Vector3(0.5f, 0.5f, 0.5f);
	    }
	    
	    private void PositionPlayer(Vector3 pos)
	    {
	    	Debug.Log("SmoothFollow: PositionPlayer " + pos);
	    	pos.z = pos.z - distance;
	    	this.transform.position = pos;
	    	thisTransform.position = pos;	    	
	    }
     
	    private void LateUpdate()
	    {
		    var newPos = Vector3.zero;
		    
		    if (useSmoothing)
		    {
			    newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, SMOOTH_TIME);
			    newPos.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, SMOOTH_TIME);
			    newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, SMOOTH_TIME);
		    }
		    else
		    {
			    newPos.x = target.position.x;
			    newPos.y = target.position.y;
			    newPos.z = target.position.z;
		    }
		    
            #region Locks
		    if (LockX)
		    {
			    newPos.x = thisTransform.position.x;
		    }
		    
		    if (LockY)
		    {
			    newPos.y = thisTransform.position.y;
		    }
		    
		    if (LockZ)
		    {
			    newPos.z = thisTransform.position.z;
		    }
            #endregion
		    
		    if (useYLimit) {
		    	if (newPos.y < yLimit) {
		    		newPos.y = yLimit;
		    	}
		    }
		    
		    transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
	    }
	    
	    void OnLevelWasLoaded(int level) 
	    {

	    }
    }
