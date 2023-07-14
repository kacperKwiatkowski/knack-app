package com.knack.user.controller

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.service.UserService
import org.springframework.http.HttpStatus
import org.springframework.security.access.prepost.PreAuthorize
import org.springframework.web.bind.annotation.*
import java.util.*

@RestController
@RequestMapping("/user")
class UserController (
    private val userService: UserService
){

    @PreAuthorize("hasAuthority('level:auth')")
    @GetMapping("/{id}")
    @ResponseStatus(HttpStatus.OK)
    fun getUser(@PathVariable id: Long): UserDTO {
        return userService.getUser(id)
    }

    @PreAuthorize("hasAuthority('level:auth')")
    @GetMapping("/all")
    @ResponseStatus(HttpStatus.OK)
    fun getAllUsers(): List<UserDTO> {
        return userService.getUsers()
    }

    @PreAuthorize("hasAuthority('level:auth')")
    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.OK)
    fun deleteUser(@PathVariable id: Long) {
        userService.deleteUser(id)
    }
}