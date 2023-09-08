using UnityEngine;

public class BoxMoveInteractable : MouseInteractable
{
   private Transform _box;
   private readonly float _moveSpeed = 1.0f;
   private bool _canPush;

   private Vector3 _targetPosition;

   private bool _finalPos;
   public Direction direction = Direction.None;
   public enum Direction
   {
      None,
      Forward,
      Left,
      Right,
      Backwards
   }

   public void OnMouseEnter()
   {
      
         _box.gameObject.GetComponent<MeshRenderer>().material.color =
            PlayerInRange() ? HighlightedColor[(int)objectHighlights] : DisabledColor;

         if (Input.GetMouseButtonDown(0) && PlayerInRange() && !_finalPos)
         {
            Interact();
         }
      
   }

   public override void OnMouseExit()
   {
      _box.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
   }

   public override void Start()
   {
      mr = GetComponentInParent<MeshRenderer>();
      _box = transform.parent.transform;
   }

   public override void Interact()
   {
      DirectionSelector();
      _canPush = true;
      Debug.Log("Interact: SUCCESS");
   }
   private void Update()
   {
      if (_canPush)
      {
         //Move our position a step closer to the target
         var step = _moveSpeed * Time.deltaTime; // calculate distance to move
         _box.transform.position = Vector3.MoveTowards(_box.position, _targetPosition, step);

         //Check if the position of the Box and target position are approximately equal.
         if (Vector3.Distance(_box.position, _targetPosition) < 0.001f)
         {
            _canPush = false;
         }
      }
   }

   private void DirectionSelector()
   {
      switch (direction)
      {
         //forward = +1 Z
         case Direction.Forward:
            _targetPosition = new Vector3(_box.position.x, _box.position.y,
               _box.position.z + 1.0f);
            break;
         //backwards = -1 Z
         case Direction.Backwards:
            _targetPosition = new Vector3(_box.position.x, _box.position.y,
               _box.position.z - 1.0f);
            break;
         //left = -1 X
         case Direction.Left:
            _targetPosition = new Vector3(_box.position.x - 1.0f, _box.position.y,
               _box.position.z);
            break;
         //right =  +1 X
         case Direction.Right:
            _targetPosition = new Vector3(_box.position.x + 1.0f, _box.position.y,
               _box.position.z);
            break;
      }
   }

   private void OnCollisionStay(Collision other)
   {
      if (!other.gameObject.CompareTag("Wall")) return;
      Debug.Log("Final Position");
      _finalPos = true;
   }
   
}





//TODO:
//create script on each empty
//mouseOver + getMouseButtonDown
//set enum to direction
//send direction to this script then run switch based on enum directions