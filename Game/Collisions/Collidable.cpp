#include "Collidable.h"

#include "Utilities/Logger/Log.h"

#include "../Physics/Movable.h"

namespace liman {

	const char* Collidable::g_Name = "CollisionComponent";

	Collidable::Collidable() = default;

	// TODO: place somewhere in settings
	//	const float g_paramColision = 1;

	// TIP: Collision result logic
	maths::Vec2f Collidable::Collide(Actor* pPairedActor, CollisionSide side) {
		auto* pMoveComp = this->GetOwner()->GetComponent<Movable>(Movable::g_Name);

		if (pMoveComp) {
			pMoveComp->SetVelocity(0.0f, 0.0f);

			pMoveComp->AddAccel(0.0f, Movable::g_gravity * 0.0001f);
		}

		return maths::Vec2f();
	}

	void Collidable::OnCollision() {
		// TODO: create collision event
	}

}