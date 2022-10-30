package com.knack.user.model

import com.knack.user.security.role.RoleType
import java.util.*
import javax.persistence.*

@Entity
data class UserEntity(

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    val id: Long,
    var firstName: String,
    var lastName: String,
    var email: String,
    var username: String,
    var contactNumber: String,
    var password: String,
    var roleType: RoleType

    )