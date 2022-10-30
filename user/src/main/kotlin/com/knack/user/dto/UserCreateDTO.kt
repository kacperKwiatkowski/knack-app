package com.knack.user.dto

import java.util.*

data class UserCreateDTO(

    val firstName: String,
    val lastName: String,
    val email: String,
    val username: String,
    val contactNumber: String,
    val password: String,
    val roleType: String,
)
