package com.knack.user.dto

import java.util.*

data class UserCreateDTO(

    var username: String,
    val firstName: String,
    val lastName: String,
    val email: String,
    val phoneNumber: String,
    var dateOfBirth: String,
    val password: String,
)
