package com.knack.user.security.jwt

import org.springframework.beans.factory.annotation.Value
import org.springframework.boot.context.properties.ConfigurationProperties
import org.springframework.context.annotation.Configuration
import org.springframework.context.annotation.PropertySource
import org.springframework.http.HttpHeaders

@Configuration
@ConfigurationProperties(prefix = "application.jwt")
class JwtConfig (
    @Value("\${application.jwt.secret-key}")
    var secretKey: String,
    @Value("\${application.jwt.token-prefix}")
    var tokenPrefix: String,
    @Value("\${application.jwt.token-expiration-after-days}")
    var tokenExpirationAfterDays: Int,
){
    fun getAuthorizationHeader(): String{
        return HttpHeaders.AUTHORIZATION;
    }
}