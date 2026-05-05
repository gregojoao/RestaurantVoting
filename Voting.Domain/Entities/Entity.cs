using System;
using Flunt.Notifications;

namespace Voting.Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>, IEquatable<Entity>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public bool Equals(Entity? other) => Id == other?.Id;

        public override bool Equals(object? obj) => Equals(obj as Entity);

        public override int GetHashCode() => Id.GetHashCode();
    }
}