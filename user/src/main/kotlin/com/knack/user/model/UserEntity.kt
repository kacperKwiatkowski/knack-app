package com.knack.user.model

import com.knack.user.security.role.RoleType
import javax.persistence.*

@Entity
@Table(name = "Userr")
data class UserEntity(

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    val id: Long,
    var username: String,
    var firstName: String,
    var lastName: String,
    var email: String,
    var phoneNumber: String,
    var dateOfBirth: String,
    var password: String,
    var roleType: RoleType
    )