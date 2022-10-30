package com.knack.user.controller

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.service.UserService
import org.springframework.http.HttpStatus
import org.springframework.security.access.prepost.PreAuthorize
import org.springframework.web.bind.annotation.*
import java.util.*

@RestController
@RequestMapping("/auth")
class AuthController (
    private val userService: UserService
){

    @PostMapping("/register")
    fun creatUser(@RequestBody userCreateRequest: UserCreateDTO): UserDTO {
        return userService.createUser(userCreateRequest)
    }
}