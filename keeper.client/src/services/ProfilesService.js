import { api } from "./AxiosService"
import { AppState } from "../AppState"
import { logger } from "../utils/Logger"

class ProfilesService {
  async getProfile(profileId) {
    const res = await api.get('api/profiles/' + profileId)
    logger.log('profile', res.data)
    AppState.profile = res.data
  }

  async getProfileVaults(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    logger.log('profile vaults', res.data)
    AppState.profileVaults = res.data
  }
  async getProfileKeeps(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/keeps')
    logger.log('profile keeps', res.data)
    AppState.profileKeeps = res.data
  }

}




export const profilesService = new ProfilesService()