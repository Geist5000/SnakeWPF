using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Snake.Hitboxes
{
    class GroupCollider : Collider
    {

        List<Collider> collider;
        public GroupCollider()
        {
            this.collider = new List<Collider>();
        }
        public GroupCollider(IEnumerable<Collider> collider):this()
        {
            if(collider != null)
                this.collider.AddRange(collider);
        }

        public void Add(Collider collider)
        {
            this.collider.Add(collider);
        }

        public void Remove(Collider collider)
        {
            this.collider.Remove(collider);
        }

        public void Clear()
        {
            this.collider.Clear();
        }

        public virtual bool DoesCollide(Collider other)
        {
            foreach (var c in collider)
            {
                if (c.DoesCollide(other))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual bool IsInside(Vector2 point)
        {
            foreach (var c in collider)
            {
                if (c.IsInside(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
