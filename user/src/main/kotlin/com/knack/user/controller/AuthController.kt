package com.knack.user.controller

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.dto.UserLoginDTO
import com.knack.user.service.AuthService
import com.knack.user.service.UserService
import org.springframework.web.bind.annotation.*
import java.util.*

@RestController
@RequestMapping("/auth")
class AuthController (
    private val authService: AuthService
){

    @PostMapping("/register")
    fun creatUser(@RequestBody userToCreate: UserCreateDTO): UserDTO {
        return authService.createUser(userToCreate)
    }
}