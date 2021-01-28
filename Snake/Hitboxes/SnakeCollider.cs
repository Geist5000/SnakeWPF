using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Snake.Hitboxes
{
    class SnakeCollider : GroupCollider
    {

        Collider head;
        public SnakeCollider(Collider head):this(head,null)
        {
        }
        public SnakeCollider(Collider head ,IEnumerable<Collider> collider) : base(collider)
        {
            this.head = head;
        }

        public override bool DoesCollide(Collider other)
        {
            if(other == this) {
                return base.DoesCollide(head);
            }
            else
            {
                return head.DoesCollide(other) || base.DoesCollide(other);
            }
            
        }

        public override bool IsInside(Vector2 point)
        {
            return head.IsInside(point) || base.IsInside(point);
        }
    }
}
