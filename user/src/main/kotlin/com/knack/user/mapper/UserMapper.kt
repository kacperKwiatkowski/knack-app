package com.knack.user.mapper

import com.knack.user.dto.UserCreateDTO
import com.knack.user.dto.UserDTO
import com.knack.user.model.UserEntity
import com.knack.user.security.role.RoleType
import org.modelmapper.ModelMapper
import org.springframework.security.crypto.password.PasswordEncoder
import org.springframework.stereotype.Component

@Component
class UserMapper(
    private val modelMapper: ModelMapper,
    private val passwordEncoder: PasswordEncoder
) {

    fun mapCreateUserDTOToUserEntity(userToMap: UserCreateDTO): UserEntity{
        val mappedUser = modelMapper.map(userToMap, UserEntity::class.java)
        mappedUser.password = passwordEncoder.encode(userToMap.password)
        mappedUser.roleType = RoleType.USER
        return mappedUser;
    }

    fun mapUserEntityToUserDTO(userToMap: UserEntity): UserDTO {

        return UserDTO(
            userToMap.id,
            userToMap.username,
            userToMap.firstName,
            userToMap.lastName,
            userToMap.email,
            userToMap.phoneNumber,
            userToMap.dateOfBirth,
            userToMap.password,
            userToMap.roleType.toString()
        )
//        return modelMapper.map(userToMap, UserDTO::class.java)
    }
}
