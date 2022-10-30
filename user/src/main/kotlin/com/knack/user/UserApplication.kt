package com.knack.user

import org.springframework.boot.autoconfigure.SpringBootApplication
import org.springframework.boot.runApplication
import org.springframework.data.jpa.repository.config.EnableJpaRepositories

@SpringBootApplication
@EnableJpaRepositories
class UserApplication

fun main(args: Array<String>) {
    runApplication<UserApplication>(*args)
}
