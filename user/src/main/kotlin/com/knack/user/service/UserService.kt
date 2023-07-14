package com.knack.user.service

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.mapper.UserMapper
import com.knack.user.repository.UserRepository
import org.springframework.stereotype.Service

@Service
class UserService(
    private val userRepository: UserRepository,
    private val userMapper: UserMapper,
) {
    fun getUser(id: Long): UserDTO {
        return userMapper.mapUserEntityToUserDTO(userRepository.findById(id).get());
    }

    fun getUsers(): List<UserDTO> {
        return userRepository.findAll().stream().map(userMapper::mapUserEntityToUserDTO).toList()
    }

    fun deleteUser(id: Long) {
        userRepository.deleteById(id)
    }
}
