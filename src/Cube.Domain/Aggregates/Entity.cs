﻿using System;

namespace Cube.Domain.Aggregates
{                                   //IEquatable can improve your perfomance. Because it will said what kind of object we are waiting for. 
    public abstract class Entity : IEquatable<Entity>
    {
        public long Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            return Equals(other);
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return true;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}
